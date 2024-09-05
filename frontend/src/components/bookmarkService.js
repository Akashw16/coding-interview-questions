import axios from "axios";

const bookmarkService = {
  getBookmarks: async () => {
    const token = localStorage.getItem("token");

    if (!token) {
      console.error("No token found in localStorage");
      return [];
    }

    try {
      const response = await axios.get(
        "http://localhost:5208/api/bookmarks/user",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      return response.data; // Ensure that the API returns an array of question IDs
    } catch (error) {
      console.error("Error fetching bookmarks:", error);
      return [];
    }
  },

  addBookmark: async (bookmarkRequest) => {
    const token = localStorage.getItem("token");

    if (!token) {
      console.error("No token found in localStorage");
      return;
    }

    try {
      await axios.post(
        "http://localhost:5208/api/bookmarks/add",
        bookmarkRequest,
        {
          headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json",
          },
        }
      );
    } catch (error) {
      console.error("Error adding bookmark:", error);
      throw error;
    }
  },

  removeBookmark: async (bookmarkRequest) => {
    const token = localStorage.getItem("token");

    if (!token) {
      console.error("No token found in localStorage");
      return;
    }

    try {
      await axios.post(
        "http://localhost:5208/api/bookmarks/remove",
        bookmarkRequest,
        {
          headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json",
          },
        }
      );
    } catch (error) {
      console.error("Error removing bookmark:", error);
      throw error;
    }
  },
};

export default bookmarkService;
